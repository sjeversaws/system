using Messages;

namespace DigitalThread.Lambda;

public class SystemAChangeHandler
{
    public void Handler(ComponentChanged modelUpdated)
    {
        /*
         * 1. Does the system exist in the graph?
         * No? Create it
         * Yes. Continue
         */
        
        /*
         * 2. Does the Object exist in the graph?
         * No?
         *      Create it. (with has_type relationship)
         *      Create relationship to system: object-[:owned_by]->system
         *      Exit (can exit here because there's no dependencies on this object)
         * Yes?
         *      Is it related to the system?
         *      No? Create relationship to system: object-[:owned_by]->system
         *      Yes? Continue
         */
        
        /*
         * 3. Query the graph for related systems
         * MATCH (upstream:System)<-[:owned_by]-(:Component)-[:allocated_by]-> (c:Component {name: 'requirement 1'}) -[:allocated_by]->(:Component)-[:owned_by]->(downstream:System)
         * RETURN upstream.name, downstream.name
         */
        
        /*
         * 4. Publish downstream change notifications
         */
    }
}