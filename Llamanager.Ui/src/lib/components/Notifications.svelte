<script lang="ts">
	import Snackbar, { Label } from '@smui/snackbar';
	import { currentNotification, type SnackbarProps } from '$lib/models/snackbar';
	import { onMount } from 'svelte';
	let snackbar: Snackbar;
    const init: SnackbarProps = { message: '', type: 'success' };
	let props = $state(init);

    onMount(() => {
        currentNotification.subscribe(notification => {
            if(notification) {
                props = notification;
                snackbar.open();
            }
        });
    });
</script>

<Snackbar bind:this={snackbar} class="sb sb-{props.type}" timeoutMs={4000}>
	<Label>{props.message}</Label>
</Snackbar>