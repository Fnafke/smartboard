import { ProjectService } from "@/services/ProjectService";
import type { Project } from "@/types/types";
import { useCallback, useEffect, useState } from "react";

const ProjectsOverview = () => {
    const [projects, setProjects] = useState<Project[]>([]);

    const fetchProjects = useCallback(async () => {
        const response = await ProjectService.fetchUserProjects();

        if (response && response.ok) {
            const data = await response.json();
            setProjects(data);
        }
    }, []);

    useEffect(() => {
        fetchProjects();
    }, [fetchProjects]);

    return (
        <>
            <h1 className="text-2xl font-bold mb-4">Projects Overview</h1>
        </>
    )
}

export default ProjectsOverview;