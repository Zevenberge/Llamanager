import { goto } from "$app/navigation";
import { fetchBackend, post } from "$lib/backend";

const PATH = "/llama/ticket"

export type LlamaTicketType = "Rfc" | "Bug";
export type LlamaTicketStatus = "Open" | "InProgress" | "Resolved" | "Closed";

export type LlamaTicket = {
    id: string;
    number: string;
    ticketType: LlamaTicketType;
    status: LlamaTicketStatus;
    summary: string;
    description: string | null;
    acceptanceCriteria: string | null;
}

export type CreateLlamaTicket = Omit<LlamaTicket, 'id' | 'number' | 'status'>;

export async function getAllLlamaTickets() {
    const result = await fetchBackend(PATH);
    if(result.ok) {
        return await result.json() as LlamaTicket[];
    }
    throw new Error("Could not load tickets");
}

export async function getLlamaTicket(id: string, fetch?: typeof globalThis.fetch) {
    const result = await fetchBackend(`${PATH}/${encodeURIComponent(id)}`, undefined, fetch);
    if(result.ok) {
        return await result.json() as LlamaTicket;
    }
    throw new Error("Could not load tickets");
}

export async function createLlamaTicket(ticket: CreateLlamaTicket) {
    const result = await fetchBackend(PATH, post(ticket));
    if(result.ok) {
        return await result.json() as LlamaTicket;
    }
    throw new Error("Could not create ticket");
}

export function navigateToLlamaTicket(ticket: LlamaTicket) {
    goto(`/tickets/${encodeURIComponent(ticket.id)}`);
}