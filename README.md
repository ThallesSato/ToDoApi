# ToDo API

**Contact information:**  
**Name**: Thalles Sato  
**Phone:**  +55 (11) 95647-6237  
https://www.linkedin.com/in/thalles-sato-79381b192/  
thalles_sato@hotmail.com  

## Endpoints
All endpoints are open and require no Authentication.

<details>
 <summary><code>POST /api/tasks</code> Create Todo </summary>

- **Description:** Add a new Todo in the database
- **Request body:**
  - Scheme: [TodoDto](#tododto)
- **Responses:**
    - 201: Created
        - Content:
            - Schema: [Todo](#todo)
        - Header:
            - Content:
                - Link to Todo created    
    - 400: Bad Request 
    - 500: Internal Server Error

</details>

<details>
 <summary><code>GET /api/tasks</code> List Todos </summary>

- **Description:** Finds all Todos in the database
- **Responses:**
    - 200: Success
        - Content:
            - Schema: Array of [Todos](#todo)
            
</details>

<details>
 <summary><code>GET /api/tasks/{id}</code> Find Todo by Id </summary>

- **Description:** Find Todo in the database by Id
- **Parameters:**
    - Id: Todo Id 
        - (in path, required)
        - Type: string (uuid)
- **Responses:**
    - 200: Success
        - Content:
            - Schema: [Todo](#todo)
    - 404: Not Found
    - 500: Internal Server Error

</details>

<details>
 <summary><code>PUT /api/tasks/{id}</code> Modify Todo </summary>

- **Description:** Find Todo in the database by Id, Update properties, and Save in the database
- **Parameters:**
    - Id: Todo Id
        - (in path, required)
        - Type: string (uuid)
- **Request body:**
    - Scheme: [TodoDto](#tododto)
- **Responses:**
    - 204: No Content
    - 400: Bad Request
    - 404: Not Found
    - 500: Internal Server Error

</details>

<details>
 <summary><code>DELETE /api/tasks/{id}</code> Delete Todo </summary>

- **Description:** Find Todo in the database by Id and exclude from the database
- **Parameters:**
    - Id: Todo Id
        - (in path, required)
        - Type: string (uuid)
- **Responses:**
    - 204: No Content
    - 404: Not Found
    - 500: Internal Server Error

</details>

## Schemes

<details>
 <summary style="font-size: 18px">TodoDto</summary>

### TodoDto

- Request scheme

>   | Field        | Type     | Mandatory |
>   |--------------|----------|-----------|
>   | Title        | String   | yes       |
>   | Description  | String   | yes       |
>   | Completed    | Boolean  | yes       |

</details>

<details>
 <summary style="font-size: 18px">Todo</summary>

### Todo

- Response scheme

>   | Field         | Type          |
>   |---------------|---------------|
>   | Id            | String (uuid) |
>   | Title         | String        |
>   | Description   | String        |
>   | Completed     | Boolean       |

</details>
