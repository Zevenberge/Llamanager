<script lang="ts">
	import type { LlamaTicketStatus } from '$lib/models/llamaTickets';
	import Tooltip, { Wrapper } from '@smui/tooltip';

	let { status }: { status: LlamaTicketStatus } = $props();
</script>

<Wrapper>
	<div class="compact-icon circle {status.toLowerCase()}">
		<span style="display: none;">{status}</span>
	</div>
    <Tooltip>{status}</Tooltip>
</Wrapper>

<style>
	.circle {
		clip-path: circle(50%);
	}

	.circle.open {
		background-color: paleturquoise;
	}

	.circle.resolved {
		background-color: green;
	}

	.circle.inprogress {
		background-color: gold;
	}

	.circle.closed {
		background-color: dimgrey;
	}
</style>
