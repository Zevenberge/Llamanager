<script lang="ts">
	import LlamaTicketStatusLight from '$lib/components/llama-tickets/LlamaTicketStatusLight.svelte';
    import LlamaTicketTypeIcon from '$lib/components/llama-tickets/LlamaTicketTypeIcon.svelte';
    let { data } = $props();
</script>

<h1 class="aligned-line">
    <LlamaTicketTypeIcon ticketType={data.ticketType} class="compact-icon" /> 
    <LlamaTicketStatusLight status={data.status} />
    <span>{data.number}</span>
</h1>

<h2>{data.summary}</h2>

<h3>Description:</h3>

<p class="multiline">{data.description}</p>

<h3>Acceptance criteria:</h3>

<p class="multiline">{data.acceptanceCriteria}</p>