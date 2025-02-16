<script lang="ts">
	import type { CreateLlamaTicket, LlamaTicketType } from '$lib/models/llamaTickets';
	import FormField from '@smui/form-field';
	import Radio from '@smui/radio';
	import TextField from '@smui/textfield';

	import HelperText from '@smui/textfield/helper-text';
	import LlamaTicketTypeIcon from './LlamaTicketTypeIcon.svelte';
	import MdiLabel from '../MdiLabel.svelte';

	let { ticket = $bindable() }: { ticket: CreateLlamaTicket } = $props();
	const ticketTypeOptions: LlamaTicketType[] = ['Rfc', 'Bug'];
</script>

<TextField label="Summary" bind:value={ticket.summary} required variant="outlined">
	{#snippet helper()}
		<HelperText>Single-line description of the ticket</HelperText>
	{/snippet}
</TextField>
		
<MdiLabel text="Ticket type">
<div class="short-radio-list">
	{#each ticketTypeOptions as option}
		<FormField>
			<Radio bind:group={ticket.ticketType} value={option} />
			{#snippet label()}
				<LlamaTicketTypeIcon ticketType={option} />
				<span>
					{option}
				</span>
			{/snippet}
		</FormField>
	{/each}
</div>
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
