export type Appsettings = {
    serverUrl: string;
}

export async function getAppsettings() {
    const response = await fetch("/appsettings.json");
    if(response.ok) {
        return await response.json() as Appsettings;
    }
    throw new Error("Could not load appsettings.");
}