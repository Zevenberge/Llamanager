import { fetchBackend } from "$lib/backend";

const PATH = "/llama/ticket"

export type LlamaTicketType = "Rfc" | "Bug";

export type LlamaTicket = {
    id: string;
    number: string;
    ticketType: LlamaTicketType;
    summary: string;
    description: string | null;
    acceptanceCriteria: string | null;
}

export async function getAllLlamaTickets() {
    const result = await fetchBackend(PATH);
    if(result.ok) {
        return await result.json() as LlamaTicket[];
    }
    throw new Error("Could not load tickets");
}