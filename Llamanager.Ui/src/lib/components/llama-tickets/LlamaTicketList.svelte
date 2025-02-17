<script lang="ts">
	import { navigateToLlamaTicket, type LlamaTicket } from "$lib/models/llamaTickets";
	import DataTable, { Body, Cell, Head, Row } from '@smui/data-table';
	import LinearProgress from '@smui/linear-progress';
	import LlamaTicketTypeIcon from "./LlamaTicketTypeIcon.svelte";
	import LlamaTicketStatusLight from "./LlamaTicketStatusLight.svelte";

    let { loaded, tickets } : { loaded: boolean, tickets: LlamaTicket[] } = $props();
</script>

<DataTable table$aria-label="User list" style="width: 100%;">
	<Head>
		<Row>
			<Cell></Cell>
			<Cell></Cell>
			<Cell numeric>#</Cell>
			<Cell style="width: 100%;">Summary</Cell>
		</Row>
	</Head>
	<Body>
		{#each tickets as ticket (ticket.id)}
			<Row onclick={() => navigateToLlamaTicket(ticket)}>
				<Cell>
					<LlamaTicketTypeIcon ticketType={ticket.ticketType} class="compact-icon"/>	
				</Cell>
				<Cell>
					<LlamaTicketStatusLight status={ticket.status} />
				</Cell>
				<Cell numeric>{ticket.number}</Cell>
				<Cell>{ticket.summary}</Cell>
			</Row>
		{/each}
	</Body>

	{#snippet progress()}
		<LinearProgress indeterminate closed={loaded} aria-label="Data is being loaded..." />
	{/snippet}
</DataTable>