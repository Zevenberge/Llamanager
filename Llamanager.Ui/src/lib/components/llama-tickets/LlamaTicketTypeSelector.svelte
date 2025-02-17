<script lang="ts">
	import type { LlamaTicketType } from "$lib/models/llamaTickets";
	import FormField from "@smui/form-field";
	import Radio from "@smui/radio";
	import LlamaTicketTypeIcon from "./LlamaTicketTypeIcon.svelte";

    let { type = $bindable() } : { type: LlamaTicketType } = $props();
	const ticketTypeOptions: LlamaTicketType[] = ['Rfc', 'Bug'];
</script>
<div class="short-radio-list">
	{#each ticketTypeOptions as option}
		<FormField>
			<Radio bind:group={type} value={option} />
			{#snippet label()}
				<LlamaTicketTypeIcon ticketType={option} />
				<span>
					{option}
				</span>
			{/snippet}
		</FormField>
	{/each}
</div>