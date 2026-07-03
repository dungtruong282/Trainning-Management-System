import { useNavigate } from "react-router-dom";

export default function Header() {
    const navigate = useNavigate();

    const fullName = localStorage.getItem("fullName");
    const role = localStorage.getItem("role");

    const handleLogout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("fullName");
        localStorage.removeItem("role");
        navigate("/login");
    };

    return (
        <header style={{
            height: "64px",
            background: "white",
            borderBottom: "1px solid #e5e7eb",
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            padding: "0 24px"
        }}>
            <h3>Train Management System</h3>

            <div>
                <strong>{fullName}</strong>
                <span style={{ marginLeft: "10px", color: "#64748b" }}>
                    {role}
                </span>

                <button
                    onClick={handleLogout}
                    style={{ marginLeft: "16px", padding: "6px 12px" }}
                >
                    Logout
                </button>
            </div>
        </header>
    );
}