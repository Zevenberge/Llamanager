<script lang="ts">
	import type { LlamaTicket } from "$lib/models/llamaTickets";
    import { mdiBugOutline, mdiStarCircleOutline } from '@mdi/js';
	import { Icon } from '@smui/button';
	import DataTable, { Body, Cell, Head, Row } from '@smui/data-table';
	import LinearProgress from '@smui/linear-progress';
	import LlamaTicketTypeIcon from "./LlamaTicketTypeIcon.svelte";

    let { loaded, tickets } : { loaded: boolean, tickets: LlamaTicket[] } = $props();
</script>

<DataTable table$aria-label="User list" style="width: 100%;">
	<Head>
		<Row>
			<Cell></Cell>
			<Cell numeric>#</Cell>
			<Cell style="width: 100%;">Summary</Cell>
		</Row>
	</Head>
	<Body>
		{#each tickets as ticket (ticket.id)}
			<Row>
				<Cell>
					<LlamaTicketTypeIcon ticketType={ticket.ticketType} />	
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