<script lang="ts">
	import EditIcon from '$lib/components/EditIcon.svelte';
	import LlamaTicketStatusLight from '$lib/components/llama-tickets/LlamaTicketStatusLight.svelte';
    import LlamaTicketTypeIcon from '$lib/components/llama-tickets/LlamaTicketTypeIcon.svelte';
	import { LLAMA_TICKETS_FRONT_END_PATH } from '$lib/models/llamaTickets.js';
	import Fab from '@smui/fab';
    let { data } = $props();
</script>

<h1 class="aligned-line">
    <LlamaTicketTypeIcon ticketType={data.ticketType} class="compact-icon" /> 
    <LlamaTicketStatusLight status={data.status} />
    <span>{data.number} - {data.summary}</span>
</h1>

<h2>Description:</h2>

<p class="multiline">{data.description}</p>

<h2>Acceptance criteria:</h2>

<p class="multiline">{data.acceptanceCriteria}</p>

<Fab color="primary" href="{LLAMA_TICKETS_FRONT_END_PATH}/{encodeURIComponent(data.id)}/edit">
	<EditIcon/>
</Fab>