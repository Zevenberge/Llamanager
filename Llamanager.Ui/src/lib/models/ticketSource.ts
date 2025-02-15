import { fetchBackend } from "$lib/backend";

type TicketSource = {
    source: string;
}

export const SELF_CONTAINED = 'llamanager';

export async function getTicketSource() {
	const response = await fetchBackend("/ticket-source");
    if(response.ok) {
        return await response.json() as TicketSource;
    }
    throw new Error("Could not load ticket source");
}

