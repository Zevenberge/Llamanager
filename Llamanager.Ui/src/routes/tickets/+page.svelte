<script lang="ts">
	import LlamaTicketList from '$lib/components/llama-tickets/LlamaTicketList.svelte';
	import NewIcon from '$lib/components/NewIcon.svelte';
	import { getAllLlamaTickets, type LlamaTicket } from '$lib/models/llamaTickets';
	import Fab from '@smui/fab';
	
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

<Fab color="primary" href="/tickets/new">
	<NewIcon/>
</Fab>
