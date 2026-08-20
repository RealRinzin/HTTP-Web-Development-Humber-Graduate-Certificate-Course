import { useEffect, useState } from "react";

export function useFetch(url:string) {
    // response data object
    const [data, setData] = useState(null);
    // loading status
    const [loading, setLoading] = useState(true);
    // Erro response
    const [error, setError] = useState(null);
    useEffect(() => {
        const fetchJobs = async () => {
            try {
                setLoading(true);
                const res = await fetch(url);
                if (!res.ok) throw new Error("Failed to fetch");
                const data = await res.json();
                setData(data);
                console.log(data);
            } catch (err: any) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchJobs();
    }, [url]);

    // Return the response object
    return { data, loading, error }

}