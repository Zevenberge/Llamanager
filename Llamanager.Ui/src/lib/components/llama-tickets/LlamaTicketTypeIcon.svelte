<script lang="ts">
	import type { LlamaTicketType } from "$lib/models/llamaTickets";
	import { mdiBugOutline, mdiStarCircleOutline } from "@mdi/js";
	import { Icon } from "@smui/button";

    let { ticketType, class: cssClass } : { ticketType: LlamaTicketType, class?: string} = $props();    
</script>
{#if ticketType == 'Bug'}
	<Icon tag="svg" viewBox="0 0 24 24" class={cssClass}>
		<path fill="currentColor" d={mdiBugOutline} />
	</Icon>
{:else}
	<Icon tag="svg" viewBox="0 0 24 24" class={cssClass}>
		<path fill="currentColor" d={mdiStarCircleOutline} />
	</Icon>
{/if}
