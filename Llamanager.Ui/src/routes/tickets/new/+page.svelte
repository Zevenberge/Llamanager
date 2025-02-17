<script lang="ts">
	import LlamaTicketCreate from "$lib/components/llama-tickets/LlamaTicketCreate.svelte";
	import SaveIcon from "$lib/components/SaveIcon.svelte";
	import { createLlamaTicket, navigateToLlamaTicket, type CreateLlamaTicket } from "$lib/models/llamaTickets";
	import { wrap } from "$lib/models/snackbar";
	import Fab from "@smui/fab";

    let ticket: CreateLlamaTicket = {
        type: 'Rfc',
        summary: '',
        description: '',
        acceptanceCriteria: '',
    };

    let inProgress = false;

    async function save(e: SubmitEvent) {
        e.preventDefault();
        inProgress = true;
        const result = await wrap({
            action: () => createLlamaTicket(ticket),
            onSuccess: "Successfully created ticket",
            onFailure: "Failed to create ticket",
        });
        inProgress = false;
        if(result.success) {
            navigateToLlamaTicket(result.value);
        }
    }
</script>

<h1>Create ticket</h1>

<form onsubmit={save}>
    <LlamaTicketCreate bind:ticket={ticket} />
    <Fab color="primary" exited={inProgress}>
        <SaveIcon/>
    </Fab>
</form>