<script lang="ts">
	import LlamaTicketCreate from "$lib/components/llama-tickets/LlamaTicketCreate.svelte";
	import SaveIcon from "$lib/components/SaveIcon.svelte";
	import type { CreateLlamaTicket } from "$lib/models/llamaTickets";
	import Fab from "@smui/fab";

    let ticket: CreateLlamaTicket = {
        ticketType: 'Rfc',
        summary: '',
        description: '',
        acceptanceCriteria: '',
    };

    async function save(e: SubmitEvent) {
        e.preventDefault();
        console.log(ticket);
    }
</script>

<h1>Create ticket</h1>

<form onsubmit={save}>
    <LlamaTicketCreate bind:ticket={ticket} />
    <Fab color="primary">
        <SaveIcon/>
    </Fab>
</form>