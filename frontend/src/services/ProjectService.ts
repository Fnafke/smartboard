const fetchUserProjects = async () => {
    try {
        const response = await fetch(`${import.meta.env.VITE_API_BASE_URL}/projects`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
            credentials: "include",
        })
        return response;
    } catch (error) {
        console.error("Error fetching user projects:", error)
    }
}

export const ProjectService = {
    fetchUserProjects
}