<script lang="ts">
	import type { CreateLlamaTicket } from '$lib/models/llamaTickets';
	import TextField from '@smui/textfield';

	import HelperText from '@smui/textfield/helper-text';
	import MdiLabel from '../MdiLabel.svelte';
	import LlamaTicketTypeSelector from './LlamaTicketTypeSelector.svelte';

	let { ticket = $bindable() }: { ticket: CreateLlamaTicket } = $props();
</script>

<TextField label="Summary" bind:value={ticket.summary} required variant="outlined">
	{#snippet helper()}
		<HelperText>Single-line description of the ticket</HelperText>
	{/snippet}
</TextField>
		
<MdiLabel text="Ticket type">
	<LlamaTicketTypeSelector bind:type={ticket.type} />
</MdiLabel>
<TextField label="Description" bind:value={ticket.description} textarea>
	{#snippet helper()}
		<HelperText>Comprehensive description of the ticket</HelperText>
	{/snippet}
</TextField>
<TextField label="Acceptence criteria" bind:value={ticket.acceptanceCriteria} textarea>
	{#snippet helper()}
		<HelperText>Measurable outcome to determine if the ticket is implemented</HelperText>
	{/snippet}
</TextField>
