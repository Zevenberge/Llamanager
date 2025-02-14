<script lang="ts">
    import { page } from '$app/state';  
	import Drawer, { AppContent, Content, Header, Title, Subtitle } from '@smui/drawer';
	import { Icon } from '@smui/button';
	import List, { Item, Text, Graphic, Separator } from '@smui/list';
    import { mdiClipboardCheckMultipleOutline, mdiPackageVariantClosed, mdiRobotConfusedOutline, mdiHomeOutline } from "@mdi/js"
	let { children } = $props();
    type NavigationEntry = {
        description: string;
        icon: string;
        path: string;
        requireSeperator?: boolean;
    };

    const navigations: NavigationEntry[] = [
        { description: "Home", icon: mdiHomeOutline, path: "/", requireSeperator: true },
        { description: "Tickets", icon: mdiClipboardCheckMultipleOutline, path: "/tickets" },
        { description: "Releases", icon: mdiPackageVariantClosed, path: "/releases" },
        { description: "Agent", icon: mdiRobotConfusedOutline, path: "/agent", requireSeperator: true },
    ]

</script>

<div class="drawer-container">
	<Drawer open>
		<Header>
			<Title>Llamanager</Title>
			<Subtitle>Your favorite cuddly manager</Subtitle>
		</Header>
		<Content>
			<List>
                {#each navigations as nav}
                    {#if nav.requireSeperator }
                        <Separator/>
                    {/if}
                    <Item href={nav.path} activated={page.url.pathname === nav.path}>
                        <Graphic aria-hidden>
                            <Icon tag="svg" viewBox="0 0 24 24">
                                <path fill="currentColor" d={nav.icon} />
                            </Icon>
                        </Graphic>
                        <Text>{nav.description}</Text>
                    </Item>
                {/each}
			</List>
		</Content>
	</Drawer>

	<AppContent class="app-content">
		<main class="main-content">
			{@render children()}
		</main>
	</AppContent>
</div>

<style>
	/* These classes are only needed because the
    drawer is in a container on the page. */
	.drawer-container {
		position: relative;
		display: flex;
		height: 100vh;
		width: 100vw;
		border: 1px solid var(--mdc-theme-text-hint-on-background, rgba(0, 0, 0, 0.1));
		overflow: hidden;
		z-index: 0;
	}

	* :global(.app-content) {
		flex: auto;
		overflow: auto;
		position: relative;
		flex-grow: 1;
	}

	.main-content {
		overflow: auto;
		padding: 16px;
		height: 100%;
		box-sizing: border-box;
	}
</style>
