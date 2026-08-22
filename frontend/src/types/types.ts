export type User = {
    id: string;
    username: string;
}

export type Project = {
    id: string;
    name: string;
    description: string;
    createdAt: Date;
    userId: string;
}