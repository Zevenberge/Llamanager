<script lang="ts">
	import LlamaTicketList from '$lib/components/llama-tickets/LlamaTicketList.svelte';
	import { getAllLlamaTickets, type LlamaTicket } from '$lib/models/llamaTickets';
	
	import { onMount } from 'svelte';

	let tickets: LlamaTicket[] = [];
	let loaded = false;
	onMount(async () => {
		try {
			tickets = await getAllLlamaTickets();
		} finally {
			loaded = true;
		}
	});
</script>

<h1>Your tickets</h1>

<LlamaTicketList loaded={loaded} tickets={tickets} />

