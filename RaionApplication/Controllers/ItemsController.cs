// <copyright file="ItemsController.cs" company="RAION SOFTWARE Sp. z o.o.">
// Copyright (c) RAION SOFTWARE Sp. z o.o.. All rights reserved.
// </copyright>

namespace RaionApplication.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RaionApplication.Extensions;
    using RaionApplication.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static readonly string ItemsLocalPath = "items.local";

        private readonly RaionApplicationContext context;

        public ItemsController(RaionApplicationContext context)
        {
            this.context = context;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> GetItem()
        {
            return this.context.Item;
        }

        [HttpGet("firstEndPoint/{text}")]
        [HttpGet("secondEndPoint/{text}")]
        public async Task<IActionResult> Get([FromRoute] string text)
        {
            // 0 is default; actual is provided by PostItem method
            return await this.PostItem(new Item() { Id = 0, Text = text });
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var item = await this.context.Item.FindAsync(id);

            if (item == null)
            {
                return this.NotFound();
            }

            return this.Ok(item);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem([FromRoute] int id, [FromBody] Item item)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != item.Id)
            {
                return this.BadRequest();
            }

            this.context.Entry(item).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ItemExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        // POST: api/Items
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] Item item)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.context.Item.Add(item);
            await this.context.SaveChangesAsync();

            try
            {
                Utils.ItemsUtil.TryToWriteLocalFile(item.Text, ItemsLocalPath);
            }
            catch (WritingToLocalFileException ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var item = await this.context.Item.FindAsync(id);
            if (item == null)
            {
                return this.NotFound();
            }

            this.context.Item.Remove(item);
            await this.context.SaveChangesAsync();

            return this.Ok(item);
        }

        private bool ItemExists(int id)
        {
            return this.context.Item.Any(e => e.Id == id);
        }
    }
}