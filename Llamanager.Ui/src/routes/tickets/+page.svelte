<script lang="ts">
	import LlamaTicketList from '$lib/components/llama-tickets/LlamaTicketList.svelte';
	import NewIcon from '$lib/components/NewIcon.svelte';
	import { getAllLlamaTickets, LLAMA_TICKETS_FRONT_END_PATH, numberToCompare, type LlamaTicket } from '$lib/models/llamaTickets';
	import Fab from '@smui/fab';
	
	import { onMount } from 'svelte';

	let tickets: LlamaTicket[] = [];
	let loaded = false;
	onMount(async () => {
		try {
			tickets = await getAllLlamaTickets();
			tickets.sort((a, b) => numberToCompare(b) - numberToCompare(a));
		} finally {
			loaded = true;
		}
	});
</script>

<h1>Your tickets</h1>

<LlamaTicketList loaded={loaded} tickets={tickets} />

<Fab color="primary" href="{LLAMA_TICKETS_FRONT_END_PATH}/new">
	<NewIcon/>
</Fab>
