<script lang="ts">
	import Dialog, { Title, Content, Actions } from '@smui/dialog';
	import Button, { Label } from '@smui/button';
	import List, { Item, Graphic, Text } from '@smui/list';
	import Radio from '@smui/radio';
	import { navigateToLlamaTicket, updateLlamaTicketStatus, type LlamaTicketStatus } from '$lib/models/llamaTickets';
	import { wrap } from '$lib/models/snackbar';

	let { open = $bindable(), status, id }: { open: boolean; status: LlamaTicketStatus, id: string } = $props();
	const statusses: LlamaTicketStatus[] = ['Open', 'InProgress', 'Resolved', 'Closed'];

	async function onClosed(e: CustomEvent<{ action: string }>) {
        if(e.detail.action === 'submit') {
            const result = await wrap({
                action: () => updateLlamaTicketStatus(id, status),
                onSuccess: "Updated status",
                onFailure: "Failed to update status",
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
	<Title id="list-selection-title">Dialog Title</Title>
	<Content id="list-selection-content">
		<List radioList>
			{#each statusses as possibleStatus}
                <Item>
                    <Graphic>
                        <Radio bind:group={status} value={possibleStatus} />
                    </Graphic>
                    <Text>{possibleStatus}</Text>
                </Item>
            {/each}
		</List>
	</Content>
	<Actions>
		<Button>
			<Label>Cancel</Label>
		</Button>
		<Button action="submit" color="primary">
			<Label>Save</Label>
		</Button>
	</Actions>
</Dialog>
