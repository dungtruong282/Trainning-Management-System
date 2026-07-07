import Header from "./Header";
import Sidebar from "./Sidebar";

export default function MainLayout({ children }) {
    return (
        <div style={{ display: "flex", minHeight: "100vh" }}>
            <Sidebar />

            <div style={{ flex: 1, background: "#f4f6f8" }}>
                <Header />

                <main style={{ padding: "24px" }}>
                    {children}
                </main>
            </div>
        </div>
    );
}