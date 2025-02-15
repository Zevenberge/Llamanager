export type Appsettings = {
    serverUrl: string;
}

export async function getAppsettings(fetch?: typeof globalThis.fetch) {
    const response = await (fetch ?? globalThis.fetch)("/appsettings.json");
    if(response.ok) {
        return await response.json() as Appsettings;
    }
    throw new Error("Could not load appsettings.");
}