import { Home, FolderKanban, Settings, Inbox, User, LayoutDashboard, ToolCase, LogOut } from "lucide-react"
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarHeader,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarMenuSub,
  SidebarMenuSubButton,
  SidebarMenuSubItem,
  SidebarProvider,
  SidebarTrigger,
} from "@/components/ui/sidebar"
import { TooltipProvider } from "./ui/tooltip"
import { AuthContext } from "./context/AuthContext";
import { useContext } from "react";

const SidebarComponent = () => {
    const context = useContext(AuthContext);

    return (
        <SidebarProvider>
            <TooltipProvider>
            <Sidebar collapsible="icon" variant="floating">
            <SidebarHeader>
                <div className="flex items-center justify-between px-2 py-1.5 group-data-[collapsible=icon]:justify-center">
                <div className="flex items-center gap-2 overflow-hidden group-data-[collapsible=icon]:hidden">
                    <div className="flex h-7 w-7 shrink-0 items-center justify-center rounded-md bg-sidebar-primary text-sidebar-primary-foreground">
                    <LayoutDashboard className="h-4 w-4" />
                    </div>
                    <span className="truncate text-sm font-semibold">Smartboard</span>
                </div>
                <SidebarTrigger className="h-7 w-7 shrink-0 rounded-md hover:bg-sidebar-accent hover:text-sidebar-accent-foreground" />
                </div>
            </SidebarHeader>

            <SidebarContent>
                <SidebarGroup>
                <SidebarGroupLabel>Smartboard</SidebarGroupLabel>
                <SidebarGroupContent>
                    <SidebarMenu>
                    <SidebarMenuItem>
                        <SidebarMenuButton asChild tooltip="Home">
                        <a href="/">
                            <Home />
                            <span>Home</span>
                        </a>
                        </SidebarMenuButton>
                    </SidebarMenuItem>

                    {/* Item with sub-menu */}
                    <SidebarMenuItem>
                        <SidebarMenuButton asChild tooltip="Projects">
                        <a href="/projects">
                            <FolderKanban />
                            <span>Projects</span>
                        </a>
                        </SidebarMenuButton>
                        <SidebarMenuSub>
                        <SidebarMenuSubItem>
                            <SidebarMenuSubButton asChild>
                            <a href="/projects/active">Active</a>
                            </SidebarMenuSubButton>
                        </SidebarMenuSubItem>
                        <SidebarMenuSubItem>
                            <SidebarMenuSubButton asChild>
                            <a href="/projects/archived">Archived</a>
                            </SidebarMenuSubButton>
                        </SidebarMenuSubItem>
                        </SidebarMenuSub>
                    </SidebarMenuItem>

                    <SidebarMenuItem>
                        <SidebarMenuButton asChild tooltip="Inbox">
                        <a href="/inbox">
                            <Inbox />
                            <span>Inbox</span>
                        </a>
                        </SidebarMenuButton>
                    </SidebarMenuItem>
                    </SidebarMenu>
                </SidebarGroupContent>
                </SidebarGroup>

                {/* Secondary group */}
                <SidebarGroup>
                <SidebarMenu>
                    <SidebarMenuItem>
                    <SidebarMenuButton asChild tooltip="Settings">
                        <a href="/settings">
                        <Settings />
                        <span>Settings</span>
                        </a>
                    </SidebarMenuButton>
                    </SidebarMenuItem>
                </SidebarMenu>
                </SidebarGroup>
            </SidebarContent>

            <SidebarFooter>
                <SidebarMenu>
                <SidebarMenuItem>
                    <SidebarMenuButton asChild tooltip="Account">
                    <a href="/account">
                        <User />
                        <span>Account</span>
                    </a>
                    </SidebarMenuButton>
                    <SidebarMenuButton asChild tooltip="Logout" className="text-red-500 hover:text-red-600 cursor-pointer">
                    <a onClick={() => context?.logout && context.logout()}>
                        <LogOut />
                        <span>Logout</span>
                    </a>
                    </SidebarMenuButton>
                </SidebarMenuItem>
                </SidebarMenu>
            </SidebarFooter>
            </Sidebar>
            </TooltipProvider>
        </SidebarProvider>
    )
}

export default SidebarComponent