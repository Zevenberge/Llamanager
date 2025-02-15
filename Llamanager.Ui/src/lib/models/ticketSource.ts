import { fetchBackend } from "$lib/backend";

type TicketSource = {
    source: string;
}

export const SELF_CONTAINED = 'llamanager';

export async function getTicketSource(fetch?: typeof globalThis.fetch) {
	const response = await fetchBackend("/ticket-source", undefined, fetch);
    if(response.ok) {
        return await response.json() as TicketSource;
    }
    throw new Error("Could not load ticket source");
}

