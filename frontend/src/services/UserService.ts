// GET ENDPOINTS

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

// POST ENDPOINTS

const signupUser = async (username: string, email: string, password: string) => {
    try {
        const response = await fetch(`${import.meta.env.VITE_API_BASE_URL}/users/signup`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
            body: JSON.stringify({ username, email, password })
        });

        return response;
    } catch (error) {
        console.error("Error signing up user:", error);
        throw error;
    }
}

const authenticateUser = async (email: string, password: string) => {
    try {
        const response = await fetch(`${import.meta.env.VITE_API_BASE_URL}/users/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
            body: JSON.stringify({ email, password })
        });

        return response;
    } catch (error) {
        console.error("Error authenticating user:", error);
        throw error;
    }
}

export const UserService = {
    fetchCurrentUser,
    authenticateUser,
    signupUser
};