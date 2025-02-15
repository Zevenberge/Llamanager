import { getTicketSource } from "$lib/models/ticketSource";

export async function load({ fetch }) {
    return await getTicketSource(fetch);
}