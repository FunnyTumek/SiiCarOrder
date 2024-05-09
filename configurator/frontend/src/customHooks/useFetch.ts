import axios from 'axios'
import { useEffect, useState } from 'react'
import { BASEURL } from '../constant/connection/ConnectionConstants'

export const useFetch = <T>(url: string): { fetchData: T | undefined, loading: boolean, error: string } => {

    const [fetchData, setFetchData] = useState<T>()
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState('')

    useEffect(() => {
        setLoading(true)
        axios
            .get(`${BASEURL + url}`)
            .then((response) => {
                setFetchData(response.data)
            })
            .catch((err) => {
                setError(err)
            })
            .finally(() => {
                setLoading(false)
            })
    }, [url]
    )
    return { fetchData, loading, error }
}

