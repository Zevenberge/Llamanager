<script lang="ts">
	import type { Snippet } from 'svelte';

	let { text, children }: { text: string; children: Snippet<[]> } = $props();
</script>

<!-- svelte-ignore a11y_label_has_associated_control -->
<label
	class="mdc-text-field mdc-text-field--label-floating actually-not-a-text-field"
>
	<span class="mdc-floating-label">
		{text}
	</span>
	{@render children()}
</label>
