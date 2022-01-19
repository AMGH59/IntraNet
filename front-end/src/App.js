import React from "react";
import {
    BrowserRouter as Router,
    Routes,
    Switch,
    Route,
} from "react-router-dom";
import './styles/index.css';
import AddMission from "./components/AddMission";
import BillsOverview from "./containers/BillsOverview";
import HolidayOverview from "./containers/HolidayOverview";
import BillById from "./containers/BillById"

function App() {
    return (
        <div className="App">
            <Router>
                <header className="header">
                    < AddMission />
                </header>
                <Routes>
                    <Route
                        path="bills"
                        element={<BillsOverview />}
                    />
                    <Route
                        path="bills/:id"
                        element={<BillById />}
                    />
                    <Route
                        path="holidays"
                        element={<HolidayOverview />}
                    />
                </Routes>
            </Router>
        </div>
    );
}

export default App;
