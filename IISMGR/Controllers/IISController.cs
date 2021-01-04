using Microsoft.Web.Administration;
using System.Web.Http;

namespace IISMGR.Controllers
{
    public class IISController : ApiController
    {
        /// <summary>
        /// 启动站点
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult StartSite(string siteName)
        {
            var webManager = new ServerManager();
            var startSite = webManager.Sites[siteName];
            if (startSite == null)
            {
                return BadRequest($"Can't not find site:{siteName}");
            }
            if (startSite.State.Equals(ObjectState.Stopped))
                startSite.Start();
            return Ok(siteName);
        }
        /// <summary>
        /// 停止站点
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult StopSite(string siteName)
        {
            var webManager = new ServerManager();
            var startSite = webManager.Sites[siteName];
            if (startSite == null)
            {
                return BadRequest($"Can't not find site:{siteName}");
            }
            if (startSite.State.Equals(ObjectState.Started))
                startSite.Stop();
            return Ok(siteName);
        }
        /// <summary>
        /// 启动应用池
        /// </summary>
        /// <param name="poolName"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult StartPool(string poolName)
        {
            var webManager = new ServerManager();
            var applicationPool = webManager.ApplicationPools[poolName];
            if (applicationPool == null)
            {
                return BadRequest($"Can't not find applicationPool:{applicationPool}");
            }
            if (applicationPool.State.Equals(ObjectState.Stopped))
                applicationPool.Start();
            return Ok(poolName);
        }
        /// <summary>
        /// 停止应用池
        /// </summary>
        /// <param name="poolName"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult StopPool(string poolName)
        {
            var webManager = new ServerManager();
            var applicationPool = webManager.ApplicationPools[poolName];
            if (applicationPool == null)
            {
                return BadRequest($"Can't not find applicationPool:{applicationPool}");
            }
            if (applicationPool.State.Equals(ObjectState.Started))
                applicationPool.Stop();
            return Ok(poolName);
        }
    }
}
