import { NavLink } from "react-router-dom";

export default function Sidebar() {
    const linkStyle = ({ isActive }) => ({
        color: "white",
        textDecoration: "none",
        padding: "10px 12px",
        borderRadius: "8px",
        background: isActive ? "#334155" : "transparent"
    });

    return (
        <aside style={{
            width: "240px",
            background: "#1e293b",
            color: "white",
            padding: "20px"
        }}>
            <h2>TMS</h2>

            <nav style={{
                display: "flex",
                flexDirection: "column",
                gap: "10px",
                marginTop: "30px"
            }}>
                <NavLink to="/dashboard" style={linkStyle}>Dashboard</NavLink>
                <NavLink to="/users" style={linkStyle}>Users</NavLink>
                <NavLink to="/departments" style={linkStyle}>Departments</NavLink>
                <NavLink to="/courses" style={linkStyle}>Courses</NavLink>
            </nav>
        </aside>
    );
}