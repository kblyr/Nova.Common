# Nova.Common

## Error Codes
Format: _Domain/Service_ + _Error Category_ + _Ordinal_
### Domains/Services
|DOMAIN/SERVICE|CODE|
|--------------|----|
|Nova.Common   |000 |
|Nova.Identity |001 |

### Error Categories
|CATEGORY|CODE|DESCRIPTION|
|--------|----|-----------|
|Fatal|F|Fatal error, message is not safe to be read by the user or contains sensitive information|
|Validation|V|Validation error, message is safe to be read by th user and contains additional data to help front-end developers to know what part of validation failed|

### Nova.Common Error Codes
|EXCEPTION|CODE|
|---------|----|
|RequestAccessDeniedException|000F00001|
