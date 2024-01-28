import { useId, forwardRef } from 'react'

const Select = forwardRef(
    function Select({ options, label, className, ...props }, ref) {
        const id = useId();

        return (
            <div className='mb-4'>
                {label && <label htmlFor={id} className='block text-sm font-bold mb-2'></label>}

                <select
                    {...props} id={id} ref={ref}
                    className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 
                    leading-tight focus:outline-none focus:shadow-outline ${className}`}
                >
                    {options?.map((option) => (
                        <option key={option} value={option}>
                            {option}
                        </option>
                    ))}
                </select>
            </div>
        )
    });

export default Select;