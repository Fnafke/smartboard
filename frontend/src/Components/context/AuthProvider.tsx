import type { User } from "@/types/types";
import { useEffect, useState, type ReactNode } from "react";
import { UserService } from "@/services/UserService";
import { AuthContext } from "./AuthContext";


export const AuthProvider = ({ children }: { children: ReactNode }) => {
    const [user, setUser] = useState<User | null>(null);
    const [isLoading, setIsLoading] = useState(true);

    const login = (userData: User) => {
        setUser(userData);
    };

    const logout = async () => {
        await UserService.logoutUser();
        setUser(null);
    };

    const fetchUserData = async () => {
        try {
            const response = await UserService.fetchCurrentUser();

            if (response.ok) {
                const userData: User = await response.json();
                setUser(userData);
            } else {
                setUser(null);
            }
        } catch {
            setUser(null);
        } finally {
            setIsLoading(false);
        }
    };

    useEffect(() => {
        fetchUserData();
    }, []);

    return (
        <AuthContext.Provider value={{ user, isLoading, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};