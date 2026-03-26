import './App.css'
import { TwitterFollowCard } from './TwitterFollowCard'

const users =[
    { username: 'vite.dev', name: 'Vite Dev', initialIsFollowing: false },
    { username: 'reactjs', name: 'ReactJs', initialIsFollowing: true },
    { username: 'twitch.tv', name: 'Twitch', initialIsFollowing: false },
    { username: 'github.com', name: 'GitHub', initialIsFollowing: false },
    { username: 'discord.com', name: 'Discord', initialIsFollowing: true }
]

export function App () {
    const formatUsername = (username) => `@${username}`
    return(
        <section className='App'>
            {
                users.map(user => {
                    const {username, name, initialIsFollowing} = user
                    return(
                        <TwitterFollowCard
                            key={username}
                            formatUsername={formatUsername}
                            username={username}
                            initialIsFollowing={initialIsFollowing}
                        >
                            {name}
                        </TwitterFollowCard>
                    )
                }
            )}
        </section>
    )
}
