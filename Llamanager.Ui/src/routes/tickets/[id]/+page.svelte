<script lang="ts">
	import ActionsIcon from '$lib/components/ActionsIcon.svelte';
	import EditIcon from '$lib/components/EditIcon.svelte';
	import LlamaTicketDeleteDialog from '$lib/components/llama-tickets/LlamaTicketDeleteDialog.svelte';
	import LlamaTicketStatusLight from '$lib/components/llama-tickets/LlamaTicketStatusLight.svelte';
	import LlamaTicketTypeIcon from '$lib/components/llama-tickets/LlamaTicketTypeIcon.svelte';
	import LlamaTicketUpdateStatusDialog from '$lib/components/llama-tickets/LlamaTicketUpdateStatusDialog.svelte';
	import LlamaTicketUpdateTypeDialog from '$lib/components/llama-tickets/LlamaTicketUpdateTypeDialog.svelte';
	import { LLAMA_TICKETS_FRONT_END_PATH } from '$lib/models/llamaTickets.js';
	import Fab from '@smui/fab';
	import IconButton from '@smui/icon-button';
	import List, { Item, Text, Separator } from '@smui/list';
	import Menu from '@smui/menu';
	let { data } = $props();
	let menu: Menu;

	let updateStatus = $state(false);
	let updateType = $state(false);
	let deleteTicket = $state(false);
</script>

<div class="aligned-line front-and-back">
	<h1 class="aligned-line">
		<IconButton onclick={() => updateType = true}>
			<LlamaTicketTypeIcon ticketType={data.ticketType} class="compact-icon" />
		</IconButton>
		<IconButton onclick={() => updateStatus = true}>
			<LlamaTicketStatusLight status={data.status} />
		</IconButton>
		<span>{data.number} - {data.summary}</span>
	</h1>
	<div>
		<IconButton onclick={() => menu.setOpen(true)}>
			<ActionsIcon />
		</IconButton>
		<Menu bind:this={menu}>
			<List>
				<Item onSMUIAction={() => { updateStatus = true }}>
					<Text>Update status</Text>
				</Item>
				<Item onSMUIAction={() => { updateType = true }}>
					<Text>Change ticket type</Text>
				</Item>
				<Separator />
				<Item onSMUIAction={() => { deleteTicket = true }}>
					<Text>Delete</Text>
				</Item>
			</List>
		</Menu>
	</div>
</div>
<h2>Description:</h2>

<p class="multiline">{data.description}</p>

<h2>Acceptance criteria:</h2>

<p class="multiline">{data.acceptanceCriteria}</p>

<Fab color="primary" href="{LLAMA_TICKETS_FRONT_END_PATH}/{encodeURIComponent(data.id)}/edit">
	<EditIcon />
</Fab>

<LlamaTicketUpdateStatusDialog id={data.id} status={data.status} bind:open={updateStatus}/>
<LlamaTicketUpdateTypeDialog id={data.id} type={data.ticketType} bind:open={updateType} />
<LlamaTicketDeleteDialog {...data} bind:open={deleteTicket} />