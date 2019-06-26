Assumptions:
1. A user can have roles in the system as well as roles specific to a resource
2. When checking if a user can perfrom an action on a resource based on multiple roles that he has, the most EXPANSIVE permissions are applied.
3. This can be changed to most restrictive permissions quickly but I went with most expansive.
4. While checking if a user can perform an action on a resource:
      a. In case user has ROLES SPECIFIC to the resource, decide based on those roles ONLY.
	  b. If user has no role specific to the resource, decide based on system_wide roles.
5. Only read, write, delete, execute, full control action types have been considered.
6. Full Control action type allows all actions.
7. 
Content:
The Models folder contains interfaces and implementations for all entities. The filenames are self-explanatory.
The Service folder contains RoleBasedAuthenticationService. The method names are self-explanatory.
It would be beneficial to start with Models folder and then move to Service folder.
I have added a ReadMeAssist picture to quickly locate required folders.
Thank you

  