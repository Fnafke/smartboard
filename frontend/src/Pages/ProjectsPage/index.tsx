import ProjectsOverview from "@/components/Projects/ProjectsOverview";
import SidebarComponent from "@/components/SidebarComponent";

const ProjectsPage = () => {
    return (
        <>
            <title>Smartboard - Projects</title>
            <div className="flex h-screen">
                <SidebarComponent />
                <ProjectsOverview />
            </div>
        </>
    )
}

export default ProjectsPage;