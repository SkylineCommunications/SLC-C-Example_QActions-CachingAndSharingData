# Skyline Example QActions Caching and Sharing

This protocol demonstrates how to buffer data that needs to be re-used across multiple QAction runs on a given element.

Following different use-case are demonstrated:
1. Store and Share: Remember/buffer data across multiple runs of QActions simply by storing the data into a parameter.
	This will cause some extra load due to the need to serialize and deserialize the data and the required parameter gets and sets.
	In most cases, this is sufficient as the above mentioned performance impact will be neglectable compared to other parts such as datasource access, getting and setting actual data parameters, etc.
	This is the best and easiest option in most cases. It also allows to chose if stored data needs to persist across element restarts or not simply by adding save option to the buffer parameter.
	This is the only option allowing to store data across element restarts.
2. Cache: Cache data for quick access across multiple runs of the same QAction.
	To be used when method 1 is not performant enough.
	Some logic will need to take care of refreshing the cache when needed (e.g. after startup).
3. Cache and Share: Share cached data across multiple QActions.
	Typically only required when needing to share data across QActions triggered on table parameters (one on table level, one on row level).
	Some logic will need to take care of refreshing the cache when needed (e.g. after startup).
	Some extra logic will need to take care of removing obsolete cached data when elements are stopped/deleted to avoid a memory leak.
