<script lang="ts">
	import { goto } from "$app/navigation";
	import LlamaTicketCreate from "$lib/components/llama-tickets/LlamaTicketCreate.svelte";
	import SaveIcon from "$lib/components/SaveIcon.svelte";
	import { createLlamaTicket, type CreateLlamaTicket } from "$lib/models/llamaTickets";
	import { currentNotification } from "$lib/models/snackbar";
	import Fab from "@smui/fab";

    let ticket: CreateLlamaTicket = {
        ticketType: 'Rfc',
        summary: '',
        description: '',
        acceptanceCriteria: '',
    };

    let inProgress = false;

    async function save(e: SubmitEvent) {
        e.preventDefault();
        try {
            inProgress = true;
            const createdTicket = await createLlamaTicket(ticket);
            currentNotification.set({
                message: "Successfully created ticket",
                type: "success"
            });
            await goto(`/tickets/${createdTicket.id}`);
        } catch {
            currentNotification.set({ 
                message: "Failed to create ticket",
                type: "error"
            });
        } finally {
            inProgress = false;
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