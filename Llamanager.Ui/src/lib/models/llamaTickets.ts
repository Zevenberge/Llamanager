import { goto } from "$app/navigation";
import { fetchBackend, post, put } from "$lib/backend";

const PATH = "/llama/ticket"

export const LLAMA_TICKETS_FRONT_END_PATH = "/tickets";

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

export function numberToCompare(ticket: LlamaTicket) {
    return +(ticket.number.substring(0, ticket.number.length - 2));
}

export type UpdateLlamaTicket = Omit<LlamaTicket, 'id' | 'number' | 'status' | 'ticketType'>;
export type CreateLlamaTicket = UpdateLlamaTicket & {
    type: LlamaTicketType
};

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

export async function updateLlamaTicket(id: string, ticket: UpdateLlamaTicket) {
    const result = await fetchBackend(`${PATH}/${encodeURIComponent(id)}`, put(ticket));
    if(result.ok) {
        return await result.json() as LlamaTicket;
    }
    throw new Error("Could not update ticket");
}

export async function updateLlamaTicketStatus(id: string, status: LlamaTicketStatus) {
    const result = await fetchBackend(`${PATH}/${encodeURIComponent(id)}/status`, put({ status }));
    if(result.ok) {
        return await result.json() as LlamaTicket;
    }
    throw new Error("Could not update status");
}
export async function updateLlamaTicketType(id: string, type: LlamaTicketType) {
    const result = await fetchBackend(`${PATH}/${encodeURIComponent(id)}/type`, put({ type }));
    if(result.ok) {
        return await result.json() as LlamaTicket;
    }
    throw new Error("Could not update status");
}

export function navigateToLlamaTicket(ticket: LlamaTicket) {
    goto(`${LLAMA_TICKETS_FRONT_END_PATH}/${encodeURIComponent(ticket.id)}`, {
        invalidateAll: true,
    });
}