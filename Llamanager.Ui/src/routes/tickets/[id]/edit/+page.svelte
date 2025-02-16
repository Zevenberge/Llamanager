<script lang="ts">
	import LlamaTicketUpdate from "$lib/components/llama-tickets/LlamaTicketUpdate.svelte";
	import SaveIcon from "$lib/components/SaveIcon.svelte";
	import { navigateToLlamaTicket, updateLlamaTicket, type UpdateLlamaTicket } from "$lib/models/llamaTickets";
	import { currentNotification } from "$lib/models/snackbar";
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
        try {
            inProgress = true;
            const createdTicket = await updateLlamaTicket(data.id, ticket);
            currentNotification.set({
                message: "Successfully updated ticket",
                type: "success"
            });
            navigateToLlamaTicket(createdTicket);
        } catch {
            currentNotification.set({ 
                message: "Failed to update ticket",
                type: "error"
            });
        } finally {
            inProgress = false;
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