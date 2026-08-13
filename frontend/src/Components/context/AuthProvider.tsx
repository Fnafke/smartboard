import type { User } from "@/types/types";
import { AuthContext } from "./AuthContext";
import { useEffect, useState, type ReactNode } from "react";
import { UserService } from "@/services/UserService";

export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [user, setUser] = useState<User | null>(null);

    const login = (userData: User) => {
        setUser(userData);
    };

    const logout = () => {
        setUser(null);
    }

    const fetchUserData = async () => {
        const response = await UserService.fetchCurrentUser();

        if (response.ok) {
            const userData: User = await response.json();
            setUser(userData);
        } else {
            logout();
        }
    }

    useEffect(() => {
        fetchUserData();
    }, []);

    return (
        <AuthContext.Provider value={{ user, login }}>
            {children}
        </AuthContext.Provider>
    );
}