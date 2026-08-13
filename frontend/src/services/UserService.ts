const fetchCurrentUser = async() => {
    try {
        const response = await fetch(`${import.meta.env.VITE_API_BASE_URL}/users/me`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
        });

        return response;
    } catch (error) {
        console.error("Error fetching current user:", error);
        throw error;
    }
}

export const UserService = {
    fetchCurrentUser
};