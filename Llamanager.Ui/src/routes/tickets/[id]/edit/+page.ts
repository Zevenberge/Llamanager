import { getLlamaTicket } from "$lib/models/llamaTickets";
import type { PageLoad } from "./$types";

export const load: PageLoad = async ({ params, fetch }) => {
    return await getLlamaTicket(params.id, fetch);
}