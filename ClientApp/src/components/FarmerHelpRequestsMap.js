import React, { useLayoutEffect } from 'react';
import { MapContainer, TileLayer, Marker } from 'react-leaflet';
import MarkerClusterGroup from 'react-leaflet-markercluster';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import 'react-leaflet-markercluster/dist/styles.min.css';

export const FarmerHelpRequestsMap = ({ farmerHelpRequests }) => {
    useLayoutEffect(() => {
        // This is needed to correctly display the map
        delete L.Icon.Default.prototype._getIconUrl;
        L.Icon.Default.mergeOptions({
            iconRetinaUrl: require('leaflet/dist/images/marker-icon-2x.png'),
            iconUrl: require('leaflet/dist/images/marker-icon.png'),
            shadowUrl: require('leaflet/dist/images/marker-shadow.png'),
        });
    }, []);

    return (
        <MapContainer center={[46.51, 6.63]} zoom={13} style={{ height: "100vh", width: "100%" }}>
            <TileLayer
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            />
            <MarkerClusterGroup>
                {farmerHelpRequests.map((request, idx) => (
                    <Marker key={idx} position={[request.location.lat, request.location.lng]} />
                ))}
            </MarkerClusterGroup>
        </MapContainer>
    );
};