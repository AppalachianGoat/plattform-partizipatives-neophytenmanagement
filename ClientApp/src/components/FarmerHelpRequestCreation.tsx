import React, {FC} from "react";
import { CreateFarmerHelpRequestDto, FarmerHelpRequestsClient } from "../api/FarmerHelpServiceClients";


const farmerHelpRequestsClient = new FarmerHelpRequestsClient();


export const FarmerHelpRequestCreation: FC = () => {

    const handleSubmit = async (event) => {
        event.preventDefault();
        await farmerHelpRequestsClient.createFarmerHelpRequest(new CreateFarmerHelpRequestDto({...event}));
    }

    return (
        <div id="farmer-help-request-creation">
            <form onSubmit={handleSubmit}>
                <div id="form-inputs">
                    <ul>
                        <li>
                            <input type="text" name="ownerUserId"  />
                        </li>
                        <li>
                            <input type="text" name="location"  />
                        </li>
                        <li>
                            <input type="date" name="startDate"  />
                        </li>
                        <li>
                            <input type="date" name="endDate"  />
                        </li>
                        <li>
                            <input type="number" name="workVolume"  />
                        </li>     
                        <li>
                            <input type="number" name="numberOfHelpers"  />
                        </li>
                    </ul>
                </div>
                <button type="submit" className="neophyten-button" id="submit-button">Submit</button>
            </form>
        </div>
    );
}

export default FarmerHelpRequestCreation;