<script lang="ts">
	import Dialog, { Title, Content, Actions } from '@smui/dialog';
	import Button, { Label } from '@smui/button';
	import List, { Item, Graphic, Text } from '@smui/list';
	import Radio from '@smui/radio';
	import { navigateToLlamaTicket, updateLlamaTicketStatus, updateLlamaTicketType, type LlamaTicketStatus, type LlamaTicketType } from '$lib/models/llamaTickets';
	import { wrap } from '$lib/models/snackbar';
	import LlamaTicketTypeSelector from './LlamaTicketTypeSelector.svelte';

	let { open = $bindable(), type, id }: { open: boolean; type: LlamaTicketType, id: string } = $props();

	async function onClosed(e: CustomEvent<{ action: string }>) {
        if(e.detail.action === 'submit') {
            const result = await wrap({
                action: () => updateLlamaTicketType(id, type),
                onSuccess: "Updated type",
                onFailure: "Failed to update type",
            });
            if(result.success) {
                navigateToLlamaTicket(result.value);
            }
        }
    }
</script>

<Dialog
	bind:open
	selection
	aria-labelledby="list-selection-title"
	aria-describedby="list-selection-content"
	onSMUIDialogClosed={onClosed}
>
	<Title id="list-selection-title">Change type</Title>
	<Content id="list-selection-content">
        <LlamaTicketTypeSelector bind:type={type} />
	</Content>
	<Actions>
		<Button color="secondary">
			<Label>Cancel</Label>
		</Button>
		<Button action="submit" color="primary">
			<Label>Save</Label>
		</Button>
	</Actions>
</Dialog>
