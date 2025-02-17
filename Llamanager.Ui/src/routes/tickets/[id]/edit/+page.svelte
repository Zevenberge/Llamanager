<script lang="ts">
	import LlamaTicketUpdate from "$lib/components/llama-tickets/LlamaTicketUpdate.svelte";
	import SaveIcon from "$lib/components/SaveIcon.svelte";
	import { navigateToLlamaTicket, updateLlamaTicket, type UpdateLlamaTicket } from "$lib/models/llamaTickets";
	import { wrap } from "$lib/models/snackbar";
	import Fab from "@smui/fab";

    let { data } = $props();

    let ticket: UpdateLlamaTicket = $state({
        summary: data.summary,
        description: data.description,
        acceptanceCriteria: data.acceptanceCriteria,
    });

    let inProgress = $state(false);

    async function save(e: SubmitEvent) {
        e.preventDefault();
        inProgress = true;
        const result = await wrap({
            action: () => updateLlamaTicket(data.id, ticket),
            onSuccess: "Successfully updated ticket",
            onFailure: "Failed to update ticket",
        });
        inProgress = false;
        if(result.success) {
            navigateToLlamaTicket(result.value);
        }
    }
</script>

<h1>Update ticket</h1>

<form onsubmit={save}>
    <LlamaTicketUpdate bind:ticket={ticket} />
    <Fab color="primary" exited={inProgress}>
        <SaveIcon/>
    </Fab>
</form>